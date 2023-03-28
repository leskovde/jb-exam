# Exam Optimizer

Given a set of topics, each defined by a number of questions and the time required to study the topic, and a constraint in the form of the total time available to study, we want to find the best way to utilize the given time.

## File Format

The problem is defined in a file with the following format:

```
<total time> <number of questions on the exam>
<number of topics>
<topic 1 time> <topic 1 questions>
<topic 2 time> <topic 2 questions>
...
```

Here is a concrete example used in `Example2.txt`:

```
8 3
4
1 2
2 3
3 4
4 5
```

## Algorithms

### Greedy

The problem cannot be solved correctly using a greedy approach. 
However, the program includes in order to compare the results and show its inefficiency.
It works by calculating the ratio of questions per time unit for each topic, and then sorting the topics by this ratio.
It then iterates over the topics, adding them to the solution if they fit in the remaining time.

There is no guarantee that this approach will find the optimal solution.
Such a counterexample is the following:

```
8 5
5
5 6
4 4
4 4
4 4
4 4
```

Due to the sorting, the program will select the first topic, which is the one with the most questions.
Then, it will fail to select another topic, because the remaining time is too small.
The optimal solution is to select two topics, each with 4 questions.

### Dynamic Programming

The actual solution uses a dynamic programming approach. 
It is based on the knapsack problem, which is a classic problem in computer science.

The issue with the knapsack problem is the occurrence of real numbers, which makes it difficult to solve.
This does not bother us due to the fact that we are working with integers - the time is in hours and the number of questions is an integer.
Since the problem definition does not allow for partial selection of topics, our case is further simplified.

We could use a recursive approach, but this would be inefficient, since we would be solving the same subproblems over and over again.
Instead of using recursion, we use a bottom-up approach, where we build the solution from smaller subproblems.

The problem could be solved with other algorithms, such as branch and bound, but the dynamic programming approach is the most familiar one.
It also makes sense in this context, since we are working with small inputs. 
We believe that making assumptions about the number of topics and the time needed to study is correct, since the problem is would not be very realistic otherwise.

The downside of the approach, as it is implemented now, is that it requires a lot of memory.
Normally, this would be concerning, but in this case, the memory requirements are not very high.
As stated above, a single student is unlikely to have more than hundreds topics to study, and his time on this Earth is limited, as it is for all of us.

## Output

The program pretty-prints the solution to the console.
The output includes a statistics section, which shows the selected topics and their coverage of the possible questions.

Here is an example output for the input in `Example2.txt` using the dynamic programming approach:

```
Exam Optimizer
--------------
Hours to prepare: 8
Number of topics: 4
Number of test questions: 3
--------------
Topics selected:
    4, 3, 1
Total: 3 topics, 8 hours, 11 questions
Coverage: 78,571% of the test questions
```

... and here is the same input using the greedy approach:

```
Exam Optimizer
--------------
Hours to prepare: 8
Number of topics: 4
Number of test questions: 3
--------------
Topics selected:
    1, 2, 3
Total: 3 topics, 6 hours, 9 questions
Coverage: 64,286% of the test questions
```

## Tests

The program covers its parser and algorithm with tests. 

The parser is tested with a number of different inputs, including invalid ones.
This ensures the parser does not crash on invalid inputs, and that it parses the inputs correctly.
The decision to represent the input in a file is arbitrary and to be frank, it might have complicated the implementation.
Thus, the time spent on the parser might as well be spent well by implementing it right.

The greedy algorithm is tested with inputs that are known to be optimal but the algorithm is not guaranteed to find the optimal solution.
On the other hand, the dynamic programming is expected to find the optimal solution on such inputs.

