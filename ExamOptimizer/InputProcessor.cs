namespace ExamOptimizer;

public class InputProcessor
{
    private int _hoursToPrepare = int.MinValue;
    private int _numberOfTestQuestions = int.MinValue;
    private int _numberOfTopics = int.MinValue;

    public int HoursToPrepare
    {
        get => _hoursToPrepare != int.MinValue ? _hoursToPrepare : throw new Exception("HoursToPrepare is not set");
        private set => _hoursToPrepare = value;
    }

    public int NumberOfTestQuestions
    {
        get => _numberOfTestQuestions != int.MinValue
            ? _numberOfTestQuestions
            : throw new Exception("NumberOfTestQuestions is not set");
        private set => _numberOfTestQuestions = value;
    }

    public int NumberOfTopics
    {
        get => _numberOfTopics != int.MinValue ? _numberOfTopics : throw new Exception("NumberOfTopics is not set");
        private set => _numberOfTopics = value;
    }

    public List<Topic> Parse(string filename)
    {
        using StreamReader reader = new StreamReader(filename);
        ParseMetadata(reader);
        
        List<Topic> topics = new List<Topic>(_numberOfTopics);

        for (int i = 0; i < _numberOfTopics; ++i)
        {
            string? line;

            try
            {
                line = reader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not read line {i + 2} from file '{filename}' due to exception: {e.Message}");
                throw;
            }

            if (line == null)
            {
                throw new Exception($"Unexpected end of file at line {i + 2}");
            }

            (int hoursToComplete, int numberOfQuestions) = ParseLine(line);
            topics.Add(new Topic(i + 1, hoursToComplete, numberOfQuestions));
        }

        if (topics.Count == _numberOfTopics)
            return topics;

        Console.WriteLine($"Expected {_numberOfTopics} topics, but got {topics.Count} topics");
        throw new Exception("Unexpected number of topics");
    }

    private void ParseMetadata(StreamReader reader)
    {
        string? line = reader.ReadLine();
        if (line == null)
        {
            throw new Exception("Unexpected end of file at line 1");
        }
        
        (_hoursToPrepare, _numberOfTestQuestions) = ParseLine(line);
        
        line = reader.ReadLine();
        if (line == null)
        {
            throw new Exception("Unexpected end of file at line 2");
        }
        
        _numberOfTopics = int.Parse(line);
    }

    private static (int firstElement, int secondElement) ParseLine(string line)
    {
        string[] parts = line.Split(' ');
        int firstElement = int.Parse(parts[0]);
        int secondElement = int.Parse(parts[1]);

        return (firstElement, secondElement);
    }
}
