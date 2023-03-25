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
        Assert.Throws<IOException>(() => _inputProcessor.Parse("MissingFile.txt"));
    }
    
    [Test]
    public void EmptyFileTest()
    {
        Assert.Throws<InvalidOperationException>(() => _inputProcessor.Parse("../../../Inputs/EmptyFile.txt"));
    }

    [Test]
    public void ProperFileDefinitionTest()
    {
        List<Topic> topics = _inputProcessor.Parse("../../../Inputs/ProperFileDefinition.txt");
        
        Assert.Equals(topics.Count, _inputProcessor.NumberOfTopics);
    }
    
    [Test]
    public void MissingHoursToPrepareTest()
    {
        Assert.Throws<InvalidOperationException>(() => _inputProcessor.Parse("../../../Inputs/MissingHoursToPrepare.txt"));
    }
    
    [Test]
    public void MissingNumberOfTestQuestionsTest()
    {
        Assert.Throws<InvalidOperationException>(() => _inputProcessor.Parse("../../../Inputs/MissingNumberOfTestQuestions.txt"));
    }
    
    [Test]
    public void MissingNumberOfTopicsTest()
    {
        Assert.Throws<InvalidOperationException>(() => _inputProcessor.Parse("../../../Inputs/MissingNumberOfTopics.txt"));
    }

    [Test]
    public void Example1Test()
    {
        List<Topic> referenceTopics = new List<Topic>()
        {

        };
        
        List<Topic> topics = _inputProcessor.Parse("../../../Inputs/Example1.txt");

        Assert.Equals(referenceTopics.Count, topics.Count);
        
        for (int i = 0; i < referenceTopics.Count; ++i)
        {
            // Records are compared by value, not by reference.
            Assert.Equals(referenceTopics[i], topics[i]);
        }
    }
    
    [Test]
    public void Example2Test()
    {
        List<Topic> referenceTopics = new List<Topic>()
        {

        };
        
        List<Topic> topics = _inputProcessor.Parse("../../../Inputs/Example2.txt");

        Assert.Equals(referenceTopics.Count, topics.Count);
        
        for (int i = 0; i < referenceTopics.Count; ++i)
        {
            // Records are compared by value, not by reference.
            Assert.Equals(referenceTopics[i], topics[i]);
        }
    }
    
    [Test]
    public void Example3Test()
    {
        List<Topic> referenceTopics = new List<Topic>()
        {

        };
        
        List<Topic> topics = _inputProcessor.Parse("../../../Inputs/Example3.txt");

        Assert.Equals(referenceTopics.Count, topics.Count);
        
        for (int i = 0; i < referenceTopics.Count; ++i)
        {
            // Records are compared by value, not by reference.
            Assert.Equals(referenceTopics[i], topics[i]);
        }
    }
}
