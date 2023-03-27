namespace ExamOptimizer;

public class GreedyAlgorithm : IExamAlgorithm
{
    public IList<Topic> Solve(IList<Topic> topics, int hoursToPrepare)
    {
        List<Topic> selectedTopics = new List<Topic>();
        int hoursLeft = hoursToPrepare;
        
        
        // Sort the topics by the number of questions per hour.
        IEnumerable<Topic> sortedTopics = topics.OrderByDescending(topic => topic.QuestionsPerHour);
        
        foreach (Topic topic in sortedTopics)
        {
            if (hoursLeft - topic.HoursToComplete >= 0)
            {
                selectedTopics.Add(topic);
                hoursLeft -= topic.HoursToComplete;
            }
        }

        return selectedTopics;
    }
}
