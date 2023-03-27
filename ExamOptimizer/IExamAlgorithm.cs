namespace ExamOptimizer;

public interface IExamAlgorithm
{
    IList<Topic> Solve(IList<Topic> topics, int hoursToPrepare);
}
