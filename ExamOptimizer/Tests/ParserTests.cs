using ExamOptimizer;

namespace Tests;

[TestFixture]
public class ParserTests
{
    private InputProcessor _inputProcessor;

    [SetUp]
    public void TestInitialize()
    {
        _inputProcessor = new InputProcessor();
    }

    [Test]
    public void MissingFileTest()
    {
        Assert.Throws<FileNotFoundException>(() => _inputProcessor.Parse("MissingFile.txt"));
    }

    [Test]
    public void EmptyFileTest()
    {
        Assert.Throws<InvalidOperationException>(() => _inputProcessor.Parse("../../../../Inputs/EmptyFile.txt"));
    }

    [Test]
    public void ProperFileDefinitionTest()
    {
        List<Topic> topics = _inputProcessor.Parse("../../../../Inputs/ProperFileDefinition.txt");

        Assert.AreEqual(topics.Count, _inputProcessor.NumberOfTopics);
    }

    [Test]
    public void MissingHoursToPrepareTest()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _inputProcessor.Parse("../../../../Inputs/MissingHoursToPrepare.txt"));
    }

    [Test]
    public void MissingNumberOfTestQuestionsTest()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _inputProcessor.Parse("../../../../Inputs/MissingNumberOfTestQuestions.txt"));
    }

    [Test]
    public void MissingNumberOfTopicsTest()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _inputProcessor.Parse("../../../../Inputs/MissingNumberOfTopics.txt"));
    }

    [Test]
    public void WrongTaskDefinitionTest()
    {
        Assert.Throws<InvalidOperationException>(() => _inputProcessor.Parse("../../../../Inputs/WrongTaskDefinition.txt"));
    }

    [Test]
    public void Example1Test()
    {
        List<Topic> referenceTopics = new List<Topic>()
        {
            new (1, 1, 2),
            new (2, 2, 3),
            new (3, 3, 4),
            new (4, 4, 5)
        };

        List<Topic> topics = _inputProcessor.Parse("../../../../Inputs/Example1.txt");
        
        Assert.AreEqual(24, _inputProcessor.HoursToPrepare);
        Assert.AreEqual(3, _inputProcessor.NumberOfTestQuestions);
        Assert.AreEqual(referenceTopics.Count, topics.Count);

        for (int i = 0; i < referenceTopics.Count; ++i)
        {
            // Records are compared by value, not by reference.
            Assert.AreEqual(referenceTopics[i], topics[i]);
        }
    }

    [Test]
    public void Example2Test()
    {
        List<Topic> referenceTopics = new List<Topic>()
        {
            new (1, 1, 2),
            new (2, 2, 3),
            new (3, 3, 4),
            new (4, 4, 5)
        };

        List<Topic> topics = _inputProcessor.Parse("../../../../Inputs/Example2.txt");
        
        Assert.AreEqual(8, _inputProcessor.HoursToPrepare);
        Assert.AreEqual(3, _inputProcessor.NumberOfTestQuestions);
        Assert.AreEqual(referenceTopics.Count, topics.Count);

        for (int i = 0; i < referenceTopics.Count; ++i)
        {
            // Records are compared by value, not by reference.
            Assert.AreEqual(referenceTopics[i], topics[i]);
        }
    }

    [Test]
    public void Example3Test()
    {
        List<Topic> topics = _inputProcessor.Parse("../../../../Inputs/Example3.txt");

        Assert.AreEqual(24, _inputProcessor.HoursToPrepare);
        Assert.AreEqual(3, _inputProcessor.NumberOfTestQuestions);
        Assert.AreEqual(20, topics.Count);
        Assert.IsTrue(topics.Count(x => x.NumberOfQuestions == 1) == 5);
        Assert.IsTrue(topics.Count(x => x.NumberOfQuestions == 2) == 5);
        Assert.IsTrue(topics.Count(x => x.NumberOfQuestions == 3) == 10);
        Assert.IsTrue(topics.Count(x => x.HoursToComplete == 1) == 10);
        Assert.IsTrue(topics.Count(x => x.HoursToComplete == 2) == 10);
    }
}
