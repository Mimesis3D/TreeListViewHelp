using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFramework.DTOs.Base;
using EntityFramework.DTOs.Interfaces;

namespace EntityFramework.DTOs
{
    public class ObjectCollectionDTO : BaseDTO
    {

        public override ObservableCollection<IHierarchicalEntity> Children
        {
            get
            {
                var children = new ObservableCollection<IHierarchicalEntity>();
                foreach (var project in ProjectList)
                {
                    if(project.ParentProjectId == null)
                    children.Add(project);
                }
                return children;
            }
        }
    }
}
