using ExamOptimizer;

if (args.Length != 1)
{
    Console.WriteLine("Usage: dotnet run <filename>");
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
List<Topic> topics = parser.Parse(args[0]);

// Sort the topics by the number of questions per hour.

IEnumerable<Topic> sortedTopics = topics.OrderByDescending(topic => topic.QuestionsPerHour);

List<Topic> selectedTopics = new List<Topic>();
int hoursLeft = parser.HoursToPrepare;

foreach (Topic topic in sortedTopics)
{
    if (hoursLeft - topic.HoursToComplete >= 0)
    {
        selectedTopics.Add(topic);
        hoursLeft -= topic.HoursToComplete;
    }
}

ResultPrinter printer = new ResultPrinter(parser.HoursToPrepare, parser.NumberOfTopics, parser.NumberOfTestQuestions);
printer.Print(selectedTopics, topics);