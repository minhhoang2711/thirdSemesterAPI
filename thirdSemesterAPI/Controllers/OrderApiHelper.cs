using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models;

namespace thirdSemesterAPI.Need
{
    public class OrderApiHelper
    {
        public int Insert(Orders order)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    var result = context.Insert_Order(order.IdCustomer, order.NumberOfTable, order.NumberOfCustomer,
                        order.IdBranch, order.BeginTime, order.EndTime, order.OrderStatus, order.Description, order.Deposit).SingleOrDefault();

                    if (result != null)
                    {
                        return result.IdOrder;
                    }

                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
        }

        public bool Verify(Orders order)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    var result = context.Update_Verify_Order_By_Id(order.IdOrder, order.IdEmployee_Verify, order.OrderStatus);

                    if (result != -1)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public bool Update(Orders order)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    var result = context.Update_Order_By_Id(order.IdOrder, order.IdEmployee_Verify, order.NumberOfTable, order.NumberOfCustomer, order.BeginTime, order.EndTime, order.Description);

                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public bool Insert_Order_Table(DataTable table)
        {
            try
            {
                using (var context = new DatBanOnlineEntities())
                {
                    var param = new SqlParameter("@OrderTableTableType", table)
                    {
                        TypeName = "dbo.OrderTableTableType"
                    };
                    object[] sqlParams =
                    {
                        param
                    };

                    var res = context.Database.ExecuteSqlCommand("Insert_Order_Table @OrderTableTableType", sqlParams);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Orders GetById(int id)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    if (id > 0)
                    {
                        var result = context.Get_Order(id).SingleOrDefault();

                        return result?.Cast<Orders>();
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Model.Models.Order_Table> GetByIdOrder(int id)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    if (id > 0)
                    {
                        var response = context.Get_List_Order_Table(id).ToList();

                        var result = response.Select(p => p.Cast<Model.Models.Order_Table>()).ToList();
                    }


                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Orders> GetAll()
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    var result = context.Get_List_Order_All().ToList();

                    return result.Select(o => o.Cast<Orders>()).ToList();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Orders> Get_List_Order_By_Status(int orderStatus)
        {
            using (var context = new DatBanOnlineEntities())
            {
                try
                {
                    var result = context.Get_List_Order_By_Status(orderStatus).ToList();

                    return result.Select(o => o.Cast<Orders>()).ToList();

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }