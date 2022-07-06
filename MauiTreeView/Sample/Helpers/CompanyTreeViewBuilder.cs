//S5
using MauiTreeView.Models;
using MauiTreeView.Sample.Models;
using MauiTreeView.Sample.Services;

namespace MauiTreeView.Sample.Helpers
{
    public class CompanyTreeViewBuilder
    {
        private XamlItemGroup FindParentDepartment(XamlItemGroup group, Department department)
        {
            if (group.GroupId == department.ParentDepartmentId)
                return group;

            if (group.Children != null)
            {
                foreach (var currentGroup in group.Children)
                {
                    var search = FindParentDepartment(currentGroup, department);

                    if (search != null)
                        return search;
                }
            }

            return null;
        }

        public XamlItemGroup GroupData(DataService service)
        {
            var company = service.GetCompany();
            var departments = service.GetDepartments().OrderBy(x => x.ParentDepartmentId);
            var employees = service.GetEmployees();

            var companyGroup = new XamlItemGroup();
            companyGroup.Name = company.CompanyName;

            foreach (var dept in departments)
            {
                var itemGroup = new XamlItemGroup();
                itemGroup.Name = dept.DepartmentName;
                itemGroup.GroupId = dept.DepartmentId;

                // Employees first
                var employeesDepartment = employees.Where(x => x.DepartmentId == dept.DepartmentId);

                foreach (var emp in employeesDepartment)
                {
                    var item = new XamlItem();
                    item.ItemId = emp.EmployeeId;
                    item.Key = emp.EmployeeName;

                    itemGroup.XamlItems.Add(item);
                }

                // Departments now
                if (dept.ParentDepartmentId == -1)
                {
                    companyGroup.Children.Add(itemGroup);
                }
                else
                {
                    XamlItemGroup parentGroup = null;

                    foreach (var group in companyGroup.Children)
                    {
                        parentGroup = FindParentDepartment(group, dept);

                        if (parentGroup != null)
                        {
                            parentGroup.Children.Add(itemGroup);
                            break;
                        }
                    }
                }
            }

            return companyGroup;
        }
    }
}