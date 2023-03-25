namespace ExamOptimizer;

public class OutputProcessor
{
    private readonly int _hoursToPrepare;
    private readonly int _numberOfTopics;
    private readonly int _numberOfTestQuestions;

    public OutputProcessor(int hoursToPrepare, int numberOfTopics, int numberOfTestQuestions)
    {
        _hoursToPrepare = hoursToPrepare;
        _numberOfTopics = numberOfTopics;
        _numberOfTestQuestions = numberOfTestQuestions;
    }

    public void Print(IList<Topic> selectedTopics)
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
            Total: {selectedTopics.Count} topics
            """;

        Console.WriteLine(outputMessage);
    }
}
