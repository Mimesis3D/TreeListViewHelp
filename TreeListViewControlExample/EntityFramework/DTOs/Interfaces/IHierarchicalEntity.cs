using System;
using System.Collections.ObjectModel;

namespace EntityFramework.DTOs.Interfaces
{
    public interface IHierarchicalEntity
    {
        public Guid? ParentObjectCollectionId { get; set; }
        public ObjectCollectionDTO? ParentObjectCollection { get; set; }
        public ProjectDTO? ParentProject { get; set; }
        public Guid? ParentProjectId { get; set; }
        public TaskDTO? ParentTask { get; set; }
        public Guid? ParentTaskId { get; set; }
        public SessionDTO? ParentSession { get; set; }
        public Guid? ParentSessionId { get; set; }

        ObservableCollection<ProjectDTO>? ProjectList { get; set; }
        ObservableCollection<TaskDTO>? TaskList { get; set; }
        ObservableCollection<SessionDTO>? SessionList { get; set; }
    }
}
