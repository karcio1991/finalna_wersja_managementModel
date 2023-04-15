using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace finalna_wersja.MyOwnControls
{
    public class DataGridBehavior : DataGrid
    {
        public DataGridBehavior() { }


        protected override void OnLoadingRow(DataGridRowEventArgs e)
        {
            base.OnLoadingRow(e);
            this.Columns[0].IsReadOnly = true;
        }


        protected override void OnCellEditEnding(DataGridCellEditEndingEventArgs e)
        {
            base.OnCellEditEnding(e);

            int rowIndex = e.Row.GetIndex();
            int columnIndex = e.Column.DisplayIndex;

            object oldValue = e.EditingElement.DataContext;
            object newValue = (e.EditingElement as TextBox)?.Text;

            User oldValueUser = oldValue as User;

            if (e.EditAction == DataGridEditAction.Cancel)
            {
                MessageBox.Show("Are you leaving?");
                return;
            }
            else
            {

                using (var context = new ManagementModelEntities())
                {
                    var searchElement = context.User.FirstOrDefault(x => x.Id == oldValueUser.Id);

                    switch (columnIndex)
                    {
                        case 1:
                            {
                                searchElement.UserName = newValue as string;
                                break;
                            }
                        case 2:
                            {
                                searchElement.FullName = newValue as string;
                                break;
                            }
                        case 3:
                            {
                                searchElement.Password = newValue as string;
                                break;
                            }
                        case 4:
                            {
                                searchElement.PhoneNumber = newValue as string;
                                break;
                            }
                    }

                    context.SaveChanges();
                }


            }



        }

    }
}
