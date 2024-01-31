using WebAPIAssessment.Model;

namespace WebAPIAssessment.IRepo
{
    public interface ITaskRepo
    {
        List<Model.Task> GetAllTasks();
        Model.Task GetTaskById(int id);
        void AddTasks(Model.Task task);
        int UpdateTasks(Model.Task task, int id);
        bool DeleteTasks(int id);
    }
}
