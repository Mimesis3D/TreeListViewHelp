using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFramework.DTOs.Interfaces;

namespace EntityFramework.DTOs.Base
{
    public abstract class BaseDTO : IEntity, IHierarchicalEntity
    {
        public Guid Id { get; set ; }
        public string? DisplayName { get; set ; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set ; }
        public DateTime ModifiedDate { get; set; }
        public string? Comments { get; set; }

        public Guid? IconId { get; set; }
        public byte[]? Icon { get; set; }

        public Guid? ParentObjectCollectionId { get; set; }
        public ObjectCollectionDTO? ParentObjectCollection { get; set; }
        public ProjectDTO? ParentProject { get; set; }
        public Guid? ParentProjectId { get; set; }
        public TaskDTO? ParentTask { get; set; }
        public Guid? ParentTaskId { get; set; }
        public SessionDTO? ParentSession { get; set; }
        public Guid? ParentSessionId { get; set; }

        public ObservableCollection<ProjectDTO>? ProjectList { get; set; } = new();
        public ObservableCollection<TaskDTO>? TaskList { get; set; } = new();
        public ObservableCollection<SessionDTO>? SessionList { get; set; } = new();

        private ObservableCollection<IHierarchicalEntity>? children;
        [NotMapped]
        public virtual ObservableCollection<IHierarchicalEntity>? Children
        {
            get
            {
                if (children == null)
                {
                    children = new ObservableCollection<IHierarchicalEntity>();
                    foreach (var project in ProjectList)
                    {
                        children.Add(project);
                    }
                    foreach (var task in TaskList)
                    {
                        children.Add(task);
                    }
                    foreach (var session in SessionList)
                    {
                        children.Add(session);
                    }
                }
                return children;
            }
            set { }
        }

        
    }
}
