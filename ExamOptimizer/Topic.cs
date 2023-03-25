namespace ExamOptimizer;

public record Topic(int Index, int HoursToComplete, int NumberOfQuestions)
{
    public double QuestionsPerHour => (double)NumberOfQuestions / HoursToComplete;
}
