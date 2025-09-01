using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MathParserNetDemo
{
    public partial class MainForm : Form
    {
        private MathParserNet.Parser _parser;
        private Dictionary<string, string> _variables;
        private Dictionary<string, string> _functions;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            _parser = new MathParserNet.Parser();
            _variables = new Dictionary<string, string>();
            _functions = new Dictionary<string, string>();

            txtEquation.Text = @"1 + 2 * 3 / (4 + 5)";

            RefreshVariablesListBox();
            tmrVarDisable.Enabled = true;
            tmrFuncDisable.Enabled = true;

            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            var rows = new[]
                        {
                            new DelegateRow {Name = "Doubler", Description = "Doubles a number (Requires 1 parameter)", ButtonText="Enable" },
                            new DelegateRow {Name = "Tripler", Description = "Triples a number (Requires 1 parameter)", ButtonText="Enable" },
                            new DelegateRow {Name = "GetSlope", Description = "Returns the slope of a line (Requires 4 parameters)", ButtonText="Enable" }
                        };

            dgDelegates.AutoGenerateColumns = false;

            var nameColumn = new DataGridViewTextBoxColumn { Name="Name", DataPropertyName = "Name", HeaderText = @"Delegate Name" };
            var descColumn = new DataGridViewTextBoxColumn { Name = "Description", DataPropertyName = "Description", HeaderText = @"Description" };
            var enableColumn = new DataGridViewButtonColumn { Name = "Enable/Disable", HeaderText = @"Enable/Disable", DataPropertyName = @"ButtonText" };

            nameColumn.Width = 118;
            descColumn.Width = 215;
            
            dgDelegates.Columns.Add(nameColumn);
            dgDelegates.Columns.Add(descColumn);
            dgDelegates.Columns.Add(enableColumn);
            
            dgDelegates.DataSource = rows;

            dgDelegates.CellClick += DgDelegatesCellClick;
        }

        void DgDelegatesCellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewColumn = dgDelegates.Columns["Enable/Disable"];
            if (dataGridViewColumn != null && (e.RowIndex < 0 || e.ColumnIndex != dataGridViewColumn.Index)) 
                return;

            var delegateFunctionName = (string) dgDelegates[0, e.RowIndex].Value;
            var enabledText = (string) dgDelegates[2, e.RowIndex].Value;

            dgDelegates[2, e.RowIndex].Value = enabledText.Equals("Enable") ? "Disable" : "Enable";

            if (enabledText.Equals("Enable"))
            {
                if (delegateFunctionName.Equals("Doubler"))
                {
                    try
                    {
                        _parser.RegisterCustomDoubleFunction("Doubler", Doubler);
                    } catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        dgDelegates[2, e.RowIndex].Value = enabledText.Equals("Enable") ? "Disable" : "Enable";
                        return;
                    }
                }
                if (delegateFunctionName.Equals("Tripler"))
                {
                    try
                    {
                        _parser.RegisterCustomDoubleFunction("Tripler", Tripler);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        dgDelegates[2, e.RowIndex].Value = enabledText.Equals("Enable") ? "Disable" : "Enable";
                        return;
                    }
                }
                if (delegateFunctionName.Equals("GetSlope"))
                {
                    try
                    {
                        _parser.RegisterCustomDoubleFunction("GetSlope", GetSlope);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        dgDelegates[2, e.RowIndex].Value = enabledText.Equals("Enable") ? "Disable" : "Enable";
                        return;
                    }
                }
            } else
            {
                try
                {
                    _parser.UnregisterCustomFunction(delegateFunctionName);
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    dgDelegates[2, e.RowIndex].Value = enabledText.Equals("Enable") ? "Disable" : "Enable";
                    return;
                }
            }
        }

        private void MainFormPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            //g.DrawLine(Pens.Black, new Point(10, 10), new Point(100, 10));

            g.Dispose();
        }

        private void GbVariablesPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.DrawLine(Pens.LightGray, new Point(275, 7), new Point(275, gbVariables.ClientSize.Height - 2));
            g.DrawLine(Pens.White, new Point(276, 7), new Point(276, gbVariables.ClientSize.Height - 2));

            g.Dispose();
        }

        private void GbFunctionsPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.DrawLine(Pens.LightGray, new Point(275, 7), new Point(275, gbVariables.ClientSize.Height - 2));
            g.DrawLine(Pens.White, new Point(276, 7), new Point(276, gbVariables.ClientSize.Height - 2));

            g.Dispose();
        }

        private void BtnSolveClick(object sender, EventArgs e)
        {
            MathParserNet.SimplificationReturnValue retval;

            txtAnswer.Text = "";
            try
            {
                retval = _parser.Simplify(txtEquation.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            txtAnswer.Text = retval.ReturnType == MathParserNet.SimplificationReturnValue.ReturnTypes.Float ?
                retval.DoubleValue.ToString(NumberFormatInfo.InvariantInfo) : retval.IntValue.ToString();
        }

        private void BtnAddFunctionClick(object sender, EventArgs e)
        {
            string funcName = txtFunctionName.Text.Trim();

            if (funcName.Length > 0 && char.IsLetter(funcName[0]))
            {
                int ndx1 = funcName.IndexOf("(");
                if (ndx1 == -1)
                {
                    MessageBox.Show(@"Your function must have parameters", @"Error!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                string funcParams = funcName.Substring(ndx1);

                funcName = funcName.Remove(ndx1);
                funcParams = funcParams.Remove(0, 1);
                funcParams = funcParams.Remove(funcParams.Length - 1, 1);

                string[] strParams = funcParams.Split(',');

                var fal = new MathParserNet.FunctionArgumentList();
                fal.AddRange(strParams);

                try
                {
                    _parser.AddFunction(funcName, fal, txtFunctionValue.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                    return;
                }

                _functions.Add(txtFunctionName.Text, txtFunctionValue.Text);
                RefreshFunctionsListBox();
            }
            else
            {
                MessageBox.Show(@"Function name is invalid!", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnAddVariableClick(object sender, EventArgs e)
        {
            string varName = txtVariableName.Text.Trim();

            if (varName.Length > 0 && char.IsLetter(varName[0]))
            {
                try
                {
                    _parser.AddVariable(varName, txtVariableValue.Text);
                    _variables.Add(varName, txtVariableValue.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
                    return;
                }
                RefreshVariablesListBox();
            }
            else
            {
                MessageBox.Show(@"Variable name is invalid!", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
            }
        }

        private void RefreshVariablesListBox()
        {
            lbVariables.Items.Clear();

            foreach (var v in _variables)
            {
                lbVariables.Items.Add(v.Key);
            }

            btnRemoveVariable.Enabled = lbVariables.Items.Count != 0;
        }

        private void RefreshFunctionsListBox()
        {
            lbFunctions.Items.Clear();

            foreach (var f in _functions)
            {
                lbFunctions.Items.Add(f.Key);
            }

            btnRemoveFunction.Enabled = lbFunctions.Items.Count != 0;
        }

        private void LbVariablesMouseHover(object sender, EventArgs e)
        {
            string item = DetermineHoveredVariablesItem();
            string value = "";

            foreach (var v in _variables.Where(v => v.Key.Equals(item)))
            {
                value = v.Value;
                break;
            }

            ttVariables.SetToolTip(lbVariables, value);
            ttVariables.ToolTipTitle = item;

            MouseInput.ResetMouseHover(lbVariables.Handle);
        }

        private void LbFunctionsMouseHover(object sender, EventArgs e)
        {
            string item = DetermineHoveredFunctionsItem();
            string value = "";

            foreach (var f in _functions.Where(f => f.Key.Equals(item)))
            {
                value = f.Value;
                break;
            }

            ttFunctions.SetToolTip(lbFunctions, value);
            ttFunctions.ToolTipTitle = item;

            MouseInput.ResetMouseHover(lbFunctions.Handle);
        }

        private string DetermineHoveredVariablesItem()
        {
            Point screenPosition = MousePosition;
            Point listBoxClientAreaPosition = lbVariables.PointToClient(screenPosition);

            int hoveredIndex = lbVariables.IndexFromPoint(listBoxClientAreaPosition);
            if (hoveredIndex != -1)
                return lbVariables.Items[hoveredIndex] as string;
            return null;
        }

        private string DetermineHoveredFunctionsItem()
        {
            Point screenPosition = MousePosition;
            Point listBoxClientAreaPosition = lbFunctions.PointToClient(screenPosition);

            int hoveredIndex = lbFunctions.IndexFromPoint(listBoxClientAreaPosition);
            if (hoveredIndex != -1)
                return lbFunctions.Items[hoveredIndex] as string;
            return null;
        }

        private void BtnRemoveVariableClick(object sender, EventArgs e)
        {
            foreach (var item in lbVariables.SelectedItems)
            {
                try
                {
                    _parser.RemoveVariable(item.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
                    RefreshVariablesListBox();
                    return;
                }
                _variables.Remove(item.ToString());
            }

            RefreshVariablesListBox();
        }

        private void BtnRemoveFunctionClick(object sender, EventArgs e)
        {
            foreach (var item in lbFunctions.SelectedItems)
            {
                string funcName = item.ToString();
                int ndx1 = funcName.IndexOf("(");

                funcName = funcName.Remove(ndx1);

                try
                {
                    _parser.RemoveFunction(funcName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error,
                               MessageBoxDefaultButton.Button1);
                    RefreshFunctionsListBox();
                    return;
                }
                _functions.Remove(item.ToString());
            }

            RefreshFunctionsListBox();
        }


        private void TmrVarDisableTick(object sender, EventArgs e)
        {
            if ((btnRemoveVariable.Enabled == false && lbVariables.SelectedItems.Count == 0) ||
                 btnRemoveVariable.Enabled && lbVariables.SelectedItems.Count > 0)
                return;

            btnRemoveVariable.Enabled = lbVariables.SelectedItems.Count > 0;
        }

        private void TmrFuncDisableTick(object sender, EventArgs e)
        {
            if ((btnRemoveFunction.Enabled == false && lbFunctions.SelectedItems.Count == 0) ||
                 btnRemoveFunction.Enabled && lbFunctions.SelectedItems.Count > 0)
                return;

            btnRemoveFunction.Enabled = lbFunctions.SelectedItems.Count > 0;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            new MathParserNetAboutBox().ShowDialog();
        }

        #region "Delegate Functions"

        private static double Doubler(double x)
        {
            return x*2;
        }

        private static double Tripler(double x)
        {
            return x*3;
        }

        private static double GetSlope(double x1, double x2, double y1, double y2)
        {
            return (y1 - y2) / (x1 - x2);
        }

        #endregion

        private class DelegateRow
        {
            public string Name
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }

            public string ButtonText
            {
                get;
                set;
            }
        }

        private static class MouseInput
        {
            private const int TME_HOVER = 0x1;

            private struct TRACKMOUSEEVENT
            {
                public int cbSize;
                public int dwFlags;
                public IntPtr hwndTrack;
                public int dwHoverTime;

                public TRACKMOUSEEVENT(IntPtr hWnd)
                {
                    this.cbSize = Marshal.SizeOf(typeof(TRACKMOUSEEVENT));
                    this.hwndTrack = hWnd;
                    this.dwHoverTime = SystemInformation.MouseHoverTime;
                    this.dwFlags = TME_HOVER;
                }

            }

            [DllImport("user32")]
            private static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

            public static void ResetMouseHover(IntPtr windowTrackingMouseHandle)
            {
                var parameterBag = new TRACKMOUSEEVENT(windowTrackingMouseHandle);

                TrackMouseEvent(ref parameterBag);
            }
        }
    }
}
