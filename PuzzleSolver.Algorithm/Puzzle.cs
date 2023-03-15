namespace PuzzleSolver.Algorithm
{
    public class Puzzle
    {
        public PuzzleState Process(List<PuzzleElement> elements, List<Tuple<int, int>> finalCondition)
        {
            var statesProcessed = 0;
            var statesProcessed2 = 0;
            var initialState = new PuzzleState(elements);
            var passedStates = new HashSet<string>();
            var queue = new Queue<PuzzleState>();
            queue.Enqueue(initialState);

            while (queue.TryDequeue(out var state))
            {
                foreach (var mutation in state.GetPossibleMutations())
                {
                    var mutatedState = state.Mutate(mutation);

                    var hash = mutatedState.GetHash();
                    statesProcessed2++;
                    if (passedStates.Contains(hash))
                        continue;

                    var found = true;

                    for (var i = 0; i < finalCondition.Count; i++)
                    {
                        var tuple = finalCondition[i];

                        if (mutatedState.ElementStates[tuple.Item1].State.StateValue != tuple.Item2)
                        {
                            found = false;

                            break;
                        }
                    }

                    if (found)
                    {
                        return mutatedState;
                    }

                    statesProcessed++;
                    passedStates.Add(hash);
                    queue.Enqueue(mutatedState);
                }
            }

            return null;
        }
    }
}
