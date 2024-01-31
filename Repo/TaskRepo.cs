using WebAPIAssessment.DataContext;
using WebAPIAssessment.IRepo;

namespace WebAPIAssessment.Repo
{
    public class TaskRepo : ITaskRepo
    {
        ApplicationDbContext _context;
        public TaskRepo(ApplicationDbContext context)
        {
            _context = context;

        }

        public List<Model.Task> GetAllTasks()
        {
            var data = _context.Tasks.ToList();
            return data;
        }

        public Model.Task GetTaskById(int id)
        {
            var data = _context.Tasks.Where(x => x.TaskId== id).FirstOrDefault();
            return data;

        }

        public void AddTasks(Model.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public int UpdateTasks(Model.Task task, int id)
        {
            var data = _context.Tasks.Where(e => e.TaskId == id).SingleOrDefault();
            if (data == null)
            {
                return 0;
            }
            else
            {
                data.TaskName = task.TaskName;
                data.TaskStatus = task.TaskStatus;
                data.TaskDescription = task.TaskDescription;
                _context.Tasks.Update(data);
                _context.SaveChanges();
                return 1;

            }

        }

        public bool DeleteTasks(int taskid)
        {

            var data = _context.Tasks.Where(x => x.TaskId == taskid).SingleOrDefault();
            if (data == null)
            {
                return false;
            }
            else
            {
                _context.Tasks.Remove(data);
                _context.SaveChanges();
                return true;
            }

        }

    }
}
