namespace PuzzleSolver.Algorithm
{
    public class PuzzleStateMutation
    {
        public PuzzleStateMutation(PuzzleElement element, State oldState, State newState)
        {
            Element = element;
            OldState = oldState;
            NewState = newState;
        }

        public State OldState { get; }
        public PuzzleElement Element { get; }
        public State NewState { get; }
        public List<MutationCondition> Conditions { get; } = new List<MutationCondition>();
        public List<Tuple<PuzzleElement, State>> Actions { get; } = new List<Tuple<PuzzleElement, State>>();
    }

    public class MutationCondition
    {
        public MutationCondition(PuzzleElement element, int expectingState)
        {
            Element = element;
            ExpectingState = expectingState;
        }

        public PuzzleElement Element { get; }
        public int ExpectingState { get; }

        public bool IsSatisfied(PuzzleState state)
        {
            return state.ElementStates[Element.Id].State.StateValue == ExpectingState;
        }
    }
}
