namespace PuzzleSolver.Algorithm
{
    public static class BuilderExtensions
    {
        public static PuzzleStateMutation AddCondition(
            this PuzzleStateMutation transition,
            PuzzleElement element,
            int isInState)
        {
            transition.Conditions.Add(new MutationCondition(element, isInState));

            return transition;
        }

        public static PuzzleStateMutation AddAction(
            this PuzzleStateMutation transition,
            PuzzleElement element,
            int newState)
        {
            transition.Actions.Add(new Tuple<PuzzleElement, State>(element, new State(newState)));

            return transition;
        }

        public static PuzzleStateMutation AddAction(
            this PuzzleStateMutation transition,
            PuzzleElement element,
            byte[] newState)
        {
            transition.Actions.Add(new Tuple<PuzzleElement, State>(element, new State(newState)));

            return transition;
        }
    }
}
