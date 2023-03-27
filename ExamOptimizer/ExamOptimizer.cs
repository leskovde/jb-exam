namespace ExamOptimizer;

public class ExamOptimizer
{
    private readonly IExamAlgorithm _algorithm;
    
    public ExamOptimizer(IExamAlgorithm algorithm)
    {
        _algorithm = algorithm;
    }

    public IList<Topic> Solve(List<Topic> topics, int hoursToPrepare)
    {
        return _algorithm.Solve(topics, hoursToPrepare);
    }
}
