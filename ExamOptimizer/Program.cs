using ExamOptimizer;

if (args.Length != 2)
{
    Console.WriteLine("Usage: dotnet run <algorithm> <filename>");
    return;
}

// We get N as the number of hours left to prepare.
// There are M topics to prepare for the exam.
// Each topic has a number of hours (T_i) needed to prepare for it.
// Each topic has a number of questions (K_i) that will be asked on the exam.
// N < sum(T_i)
// The exam will have L questions selected from all the topics.
// We need to maximize the number of questions we will be able to answer.

InputProcessor parser = new InputProcessor();
List<Topic> topics;
try
{
    topics = parser.Parse(args[1]);
}
catch (FileNotFoundException e)
{
    Console.WriteLine($"Could not find file '{args[1]}': {e.Message}");
    return;
}
catch (Exception e)
{
    Console.WriteLine($"Could not parse file '{args[1]}': {e.Message}");
    return;
}

IExamAlgorithm? algorithm = null;

if (args[0] == "-g" || args[0] == "--greedy")
{
    algorithm = new GreedyAlgorithm();
}

if (args[0] == "-d" || args[0] == "--dynamic")
{
    algorithm = new KnapsackAlgorithm();
}

if (algorithm == null)
{
    throw new Exception($"Unknown algorithm '{args[0]}'");
}

List<Topic> selectedTopics = algorithm.Solve(topics, parser.HoursToPrepare).ToList();

ResultPrinter printer = new ResultPrinter(parser.HoursToPrepare, parser.NumberOfTopics, parser.NumberOfTestQuestions);
printer.Print(selectedTopics, topics);