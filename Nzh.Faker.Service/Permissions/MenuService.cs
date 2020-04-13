﻿using Nzh.Faker.IRepository;
using Nzh.Faker.IService;
using Nzh.Faker.IService.Permissions;
using Nzh.Faker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Faker.Service
{
    public class MenuService : BaseService<MenuModel>, IMenuService
    {
        public IMenuRepository ModuleRepository { get; set; }

        public IButtonService ButtonService { get; set; }

        public IRoleAuthorizeService RoleAuthorizeService { get; set; }


        public dynamic GetListByFilter(MenuModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }

        public dynamic GetModuleList(int roleId)
        {
            IEnumerable<MenuModel> allMenus = GetModuleListByRoleId(roleId);
            List<Tree> treeList = new List<Tree>();
            var rootMenus = allMenus.Where(x => x.ParentId == 0).OrderBy(x => x.SortCode);
            foreach (var item in rootMenus)
            {
                var _tree = new Tree { id = item.Id, title = item.FullName, href = item.UrlAddress, fontFamily = item.FontFamily, icon = item.Icon };
                GetModuleListByModuleId(treeList, allMenus, _tree, item.Id);
                treeList.Add(_tree);
            }
            var result = treeList;
            return result;
        }

        private void GetModuleListByModuleId(List<Tree> treeList, IEnumerable<MenuModel> allMenus, Tree tree, int moduleId)
        {
            var childMenus = allMenus.Where(x => x.ParentId == moduleId).OrderBy(x => x.SortCode);
            if (childMenus != null && childMenus.Count() > 0)
            {
                List<Tree> _children = new List<Tree>();
                foreach (var item in childMenus)
                {
                    var _tree = new Tree { id = item.Id, title = item.FullName, href = item.UrlAddress, fontFamily = item.FontFamily, icon = item.Icon };
                    _children.Add(_tree);
                    tree.children = _children;
                    GetModuleListByModuleId(treeList, allMenus, _tree, item.Id);
                }
            }
        }

        private IEnumerable<MenuModel> GetModuleListByRoleId(int roleId)
        {
            string sql = @"SELECT b.* FROM roleauthorize a
                           INNER JOIN menu b ON a.ModuleId = b.Id";
            var list = ModuleRepository.GetModuleListByRoleId(sql, roleId);
            return list;
        }

        public IEnumerable<TreeSelect> GetModuleTreeSelect()
        {
            IEnumerable<MenuModel> moduleList = BaseRepository.GetAll("Id,FullName,ParentId", "ORDER BY SortCode ASC");
            var rootModuleList = moduleList.Where(x => x.ParentId == 0).OrderBy(x => x.SortCode);
            List<TreeSelect> treeSelectList = new List<TreeSelect>();
            foreach (var item in rootModuleList)
            {
                TreeSelect tree = new TreeSelect
                {
                    id = item.Id,
                    name = item.FullName,
                    open = false
                };
                GetModuleChildren(treeSelectList, moduleList, tree, item.Id);
                treeSelectList.Add(tree);
            }
            return treeSelectList;
        }

        private void GetModuleChildren(List<TreeSelect> treeSelectList, IEnumerable<MenuModel> moduleList, TreeSelect tree, int id)
        {
            var childModuleList = moduleList.Where(x => x.ParentId == id).OrderBy(x => x.SortCode);
            if (childModuleList != null && childModuleList.Count() > 0)
            {
                List<TreeSelect> _children = new List<TreeSelect>();
                foreach (var item in childModuleList)
                {
                    TreeSelect _tree = new TreeSelect
                    {
                        id = item.Id,
                        name = item.FullName,
                        open = false
                    };
                    _children.Add(_tree);
                    tree.children = _children;
                    GetModuleChildren(treeSelectList, moduleList, _tree, item.Id);
                }
            }
        }

        public IEnumerable<MenuModel> GetModuleButtonList(int roleId)
        {
            string returnFields = "Id,ParentId,FullName,Icon,SortCode";
            string orderby = "ORDER BY SortCode ASC";
            IEnumerable<MenuModel> list = GetAll(returnFields, orderby);
            foreach (var item in list)
            {
                item.ModuleButtonHtml = ButtonService.GetButtonListHtmlByRoleIdModuleId(roleId, item.Id);
                item.IsChecked = RoleAuthorizeService.GetListByRoleIdModuleId(roleId, item.Id).Count() > 0 ? true : false;
            }
            return list;
        }
    }
}