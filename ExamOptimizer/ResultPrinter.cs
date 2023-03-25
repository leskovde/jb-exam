namespace ExamOptimizer;

public class ResultPrinter
{
    private readonly int _hoursToPrepare;
    private readonly int _numberOfTopics;
    private readonly int _numberOfTestQuestions;

    public ResultPrinter(int hoursToPrepare, int numberOfTopics, int numberOfTestQuestions)
    {
        _hoursToPrepare = hoursToPrepare;
        _numberOfTopics = numberOfTopics;
        _numberOfTestQuestions = numberOfTestQuestions;
    }

    public void Print(IList<Topic> selectedTopics, IList<Topic> allTopics)
    {
        string outputMessage = $"""
            Exam Optimizer
            --------------
            Hours to prepare: {_hoursToPrepare}
            Number of topics: {_numberOfTopics}
            Number of test questions: {_numberOfTestQuestions}
            --------------
            Topics selected:
                {string.Join(", ", selectedTopics.Select(x => x.Index))}
            Total: {selectedTopics.Count} topics, {selectedTopics.Sum(x => x.HoursToComplete)} hours, {selectedTopics.Sum(x => x.NumberOfQuestions)} questions
            Coverage: {100.0 * selectedTopics.Sum(x => x.NumberOfQuestions) / allTopics.Sum(x => x.NumberOfQuestions), 6:F3}% of the test questions
            """;

        Console.WriteLine(outputMessage);
    }
}
