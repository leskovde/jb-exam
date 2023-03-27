namespace ExamOptimizer;

public class KnapsackAlgorithm : IExamAlgorithm
{
    public IList<Topic> Solve(IList<Topic> topics, int hoursToPrepare)
    {
        int[,] topicsTable = new int[topics.Count + 1, hoursToPrepare + 1];
        
        // Reach maximum amount of questions.
        for (int i = 1; i <= topics.Count; i++)
            for (int j = 1; j <= hoursToPrepare; j++)
                if (topics[i - 1].HoursToComplete <= j)
                {
                    topicsTable[i, j] = Math.Max(topicsTable[i - 1, j],
                        topicsTable[i - 1, j - topics[i - 1].HoursToComplete] + topics[i - 1].NumberOfQuestions);
                }
                else
                    topicsTable[i, j] = topicsTable[i - 1, j];
        
        // Get the topics that contributed to the solution.
        List<Topic> selectedTopics = new();
        int hoursLeft = hoursToPrepare;
        
        for (int i = topics.Count; i > 0; i--)
        {
            if (topicsTable[i, hoursLeft] != topicsTable[i - 1, hoursLeft])
            {
                selectedTopics.Add(topics[i - 1]);
                hoursLeft -= topics[i - 1].HoursToComplete;
            }
        }
        
        return selectedTopics;
    }
}
