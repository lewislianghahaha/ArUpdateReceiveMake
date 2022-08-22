using System;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Core.List.PlugIn;

namespace ArUpdateReceiveMake
{
    public class ButtonEvents : AbstractListPlugIn
    {
        Generate generate=new Generate();

        public override void BarItemClick(BarItemClickEventArgs e)
        {
            //定义主键变量(用与收集所选中的行主键值)
            var flistid = string.Empty;
            //中转判断值
            var tempstring = string.Empty;
            //返回信息记录
            var mesage = string.Empty;

            base.BarItemClick(e);

            //应收单列表-点击"更新应收单回签"按钮时执行
            if (e.BarItemKey == "tbReceiveMake")
            {
                //获取列表上通过复选框勾选的记录
                var selectedrows = this.ListView.SelectedRowsInfo;
                //判断没选择记录时弹出异常提示
                if (selectedrows.Count == 0)
                {
                    View.ShowMessage("检测到没有选择记录,请选择单据记录后继续");
                }

                //判断需要有选择记录时才继续
                else
                {
                    //通过循环将选中行的主键进行收集(注:去除重复的选项,只保留不重复的主键记录)
                    foreach (var row in selectedrows)
                    {
                        if (string.IsNullOrEmpty(flistid))
                        {
                            flistid = "'" + Convert.ToString(row.BillNo) + "'";
                            tempstring = Convert.ToString(row.BillNo);
                        }
                        else
                        {
                            if (tempstring != Convert.ToString(row.BillNo))
                            {
                                flistid += "," + "'" + Convert.ToString(row.BillNo) + "'";
                                tempstring = Convert.ToString(row.BillNo);
                            }
                        }
                    }

                }

                //View.ShowMessage(flistid);

                //根据所获取的单据号进行批量更新
                var result = generate.UpdateMake(flistid);
                mesage = result == "Finish" ? "所选择的应收单,更新成功" : $"操作异常,原因:'{result}'";
                //if (result != "Finish")
                //{
                    View.ShowMessage(mesage);
               // }
            }
        }
    }
}
