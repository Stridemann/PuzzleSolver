namespace PuzzleSolver.Algorithm
{
    using System.Diagnostics.Contracts;
    using System.Text;

    public class PuzzleState
    {
        /// <summary>
        /// key - elementId
        /// </summary>
        public PuzzleElementState[] ElementStates { get; set; }

        public string MutationChanges { get; set; }

        public PuzzleState(int elements)
        {
            ElementStates = new PuzzleElementState[elements];
        }

        public PuzzleState(List<PuzzleElement> elements)
        {
            ElementStates = new PuzzleElementState[elements.Count];

            foreach (var element in elements)
            {
                ElementStates[element.Id] = new PuzzleElementState(element, new State(element.InitialState));
            }
        }

        [Pure]
        public string GetHash()
        {
            var sb = new StringBuilder();

            foreach (var state in ElementStates)
            {
                state.WriteState(sb);
            }

            return sb.ToString();
        }

        [Pure]
        public IEnumerable<PuzzleStateMutation> GetPossibleMutations()
        {
            foreach (var puzzleElementState in ElementStates)
            {
                var elementState = puzzleElementState;

                if (elementState.Element.Mutations.TryGetValue(elementState.State.StateValue, out var mutations))
                {
                    foreach (var mutation in mutations)
                    {
                        if (mutation.Conditions.All(x => x.IsSatisfied(this)))
                        {
                            yield return mutation;
                        }
                    }
                }
            }

            var state = GetHash();
        }

        [Pure]
        public PuzzleState Mutate(PuzzleStateMutation mutation)
        {
            var puzzleState = new PuzzleState(ElementStates.Length)
            {
                MutationChanges = $"{MutationChanges}{Environment.NewLine}"
            };

            for (var i = 0; i < puzzleState.ElementStates.Length; i++)
            {
                puzzleState.ElementStates[i] = ElementStates[i];
            }

            foreach (var mutationAction in mutation.Actions)
            {
                var oldState = puzzleState.ElementStates[mutationAction.Item1.Id];
                puzzleState.ElementStates[mutationAction.Item1.Id] = new PuzzleElementState(mutationAction.Item1, mutationAction.Item2);
                puzzleState.MutationChanges += $"[{mutationAction.Item1.ElementName}:{oldState.State}->{mutationAction.Item2}]";
            }

            return puzzleState;
        }
    }
}
