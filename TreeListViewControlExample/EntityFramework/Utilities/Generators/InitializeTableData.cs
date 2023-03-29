using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFramework.DTOs;
using EntityFramework.Utilities.Generators.Base;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using System;

namespace EntityFramework.Utilities.Generators
{
    public class InitializeTableData : TableSeedGtrBase
    {
        private readonly ProjectsTableSeedGtr _projectTableSeedGtr;
        private readonly SessionsTableSeedGtr _sessionTableSeedGtr;
        private readonly TasksTableSeedGtr _taskTableSeedGtr;
        private readonly ObjectCollectionTableSeedGtr _objectCollectionTableSeedGtr;

        private List<ObjectCollectionDTO> objectCollection { get; set; }
        private List<ProjectDTO> projects { get; set;}
        private List<SessionDTO> sessions { get; set; }
        private List<TaskDTO> tasks { get; set; }

        public DelegateCommand InitializeDataBaseCommand { get; set; }
        public InitializeTableData(DbContext dbContext) : base(dbContext)
        {
            _projectTableSeedGtr = new (dbContext);
            _sessionTableSeedGtr = new (dbContext);
            _taskTableSeedGtr = new (dbContext);
            _objectCollectionTableSeedGtr = new (dbContext);

            InitializeDataBaseCommand = new DelegateCommand(async () => await InitializeDataBase());
        }
        protected async ValueTask InitializeDataBase()
        {
            
            await _objectCollectionTableSeedGtr.InitializeDataTable();
            await _projectTableSeedGtr.InitializeDataTable();
            await _sessionTableSeedGtr.InitializeDataTable();
            await _taskTableSeedGtr.InitializeDataTable();

            if (_dbContext == null) return;

            objectCollection = await _dbContext.Set<ObjectCollectionDTO>().ToListAsync();
            projects = await _dbContext.Set<ProjectDTO>().ToListAsync();
            sessions = await _dbContext.Set<SessionDTO>().ToListAsync();
            tasks = await _dbContext.Set<TaskDTO>().ToListAsync();

            await InitializeProjectList();
            await InitializeTaskList();
            await InitializeSessionList();

            await InitializeObjectCollection();
        }

        private async ValueTask InitializeProjectList()
        {
            if (_dbContext == null) return;

            int p = 0;
            int s = 0;

            foreach (var project in projects)
            {
                if (projects.IndexOf(project) > 19)
                {
                    project.ParentProjectId = projects[s].Id;
                    project.ParentProject = projects[p];
                    projects[s].ProjectList?.Add(project);
                    s++;
                }
                p++;
            }
            await _dbContext.SaveChangesAsync();
        }
        private async ValueTask InitializeTaskList()
        {
            if (_dbContext == null) return;

            int p = 0;
            int s = 0;

            foreach (var task in tasks)
            {
                if (tasks.IndexOf(task) > 19)
                {
                    task.ParentProjectId = projects[s].Id;
                    task.ParentProject = projects[p];
                    projects[s].TaskList?.Add(task);
                    s++;
                }
                p++;
            }
            await _dbContext.SaveChangesAsync();
        }
        private async ValueTask InitializeSessionList()
        {
            if (_dbContext == null) return;

            int p = 0;
            int s = 0;

            foreach (var session in sessions)
            {
                if (sessions.IndexOf(session) > 19)
                {
                    session.ParentProjectId = projects[s].Id;
                    session.ParentProject = projects[p];
                    projects[s].SessionList?.Add(session);
                    s++;
                }
                p++;
            }
            await _dbContext.SaveChangesAsync();
        }
        private async ValueTask InitializeObjectCollection()
        {
            if (_dbContext == null) return;

            foreach (var project in projects)
            {
                if (project.ParentProjectId == null)
                {
                    objectCollection[0].ProjectList?.Add(project);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
