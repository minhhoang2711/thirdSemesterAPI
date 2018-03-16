using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thirdSemesterAPI.Models.Entity;

namespace thirdSemesterAPI.Models.RoleModel
{
    public class RoleModel
    {
        private ProjectAptechIIIEntities2 data = new ProjectAptechIIIEntities2();

        // Xuất ra tất cả sản phẩm
        public List<RoleEntity> GetAllRole()
        {
            try
            {
                return data.Roles.Select(p => new RoleEntity()
                {
                    Id = p.Id,
                    NameRole = p.NameRole,
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Xuất ra sản phẩm theo id sản phẩm 
        public RoleEntity GetRoleById(int id)
        {
            try
            {
                return data.Roles.Select(p => new RoleEntity()
                {
                    Id = p.Id,
                    NameRole = p.NameRole,
                }).FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Xuất ra sản phẩm theo giá sản phẩm
        public List<RoleEntity> GetRoleByNameRole(string NameRole)
        {
            try
            {
                return data.Roles.Select(p => new RoleEntity()
                {
                    Id = p.Id,
                    NameRole = p.NameRole,
                }).Where(p => p.NameRole.Contains(NameRole)).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool AddNewRole(RoleEntity p)
        {
            try
            {
                var newRole = new Role()
                {
                    Id = p.Id,
                    NameRole = p.NameRole,
                };
                data.Roles.Add(newRole);
                data.SaveChanges();
                if (newRole.Id != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateRoleById(int id, RoleEntity Role)
        {
            try
            {
                var updateRole = data.Roles.Find(id);
                updateRole.NameRole = (Role.NameRole != null) ? Role.NameRole : updateRole.NameRole;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRoleById(int id)
        {
            try
            {
                var updateRole = data.Roles.Find(id);
                data.Roles.Remove(updateRole);
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}