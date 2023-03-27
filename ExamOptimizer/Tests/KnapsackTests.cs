using ExamOptimizer;

namespace Tests;

[TestFixture]
public class KnapsackTests
{
    private IExamAlgorithm _algorithm = new KnapsackAlgorithm();

    [Test]
    public void KnapsackGreedyPositiveScenarioTest()
    {
        List<Topic> topics = new List<Topic>
        {
            new(1, 1, 1),
            new(2, 2, 9),
            new(3, 1, 1),
            new(4, 1, 1),
            new(5, 8, 10)
        };

        IList<Topic> selectedTopics = _algorithm.Solve(topics, 10);

        Assert.AreEqual(19, selectedTopics.Sum(x => x.NumberOfQuestions));
    }
    
    [Test]
    public void KnapsackGreedyInvalidTest()
    {
        List<Topic> topics = new List<Topic>
        {
            new(1, 5, 6),
            new(2, 4, 4),
            new(3, 4, 4),
            new(4, 4, 4),
            new(5, 4, 4)
        };

        IList<Topic> selectedTopics = _algorithm.Solve(topics, 8);

        Assert.AreEqual(8,  selectedTopics.Sum(x => x.NumberOfQuestions));
    }
    
    [Test]
    public void KnapsackSameRatioTest()
    {
        List<Topic> topics = new List<Topic>
        {
            new(1, 1, 1),
            new(3, 3, 3),
            new(4, 4, 4),
            new(5, 5, 5),
            new(6, 6, 6),
            new(7, 7, 7),
            new(8, 8, 8),
            new(9, 9, 9),
            new(10, 10, 10)
        };

        IList<Topic> selectedTopics = _algorithm.Solve(topics, 10);

        Assert.AreEqual(10, selectedTopics.Sum(x => x.NumberOfQuestions));
    }
}
