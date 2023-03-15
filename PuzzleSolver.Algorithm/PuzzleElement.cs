namespace PuzzleSolver.Algorithm
{
    public class PuzzleElement
    {
        public PuzzleElement(byte id, string elementName, byte initialState)
        {
            Id = id;
            ElementName = elementName;
            InitialState = initialState;
        }

        public string ElementName { get; }
        public byte Id { get; }
        public byte InitialState { get; }

        /// <summary>
        /// Key - old state
        /// </summary>
        public Dictionary<int, List<PuzzleStateMutation>> Mutations { get; } = new Dictionary<int, List<PuzzleStateMutation>>();

        public PuzzleStateMutation AddMutation(int oldState, int newState)
        {
            return AddMutation(new State(oldState), new State(newState));
        }

        public PuzzleStateMutation AddMutation(int oldState, byte[] newState)
        {
            return AddMutation(new State(oldState), new State(newState));
        }

        public PuzzleStateMutation AddMutation(byte[] oldState, int newState)
        {
            return AddMutation(new State(oldState), new State(newState));
        }

        public PuzzleStateMutation AddMutation(State oldState, State newState)
        {
            if (!Mutations.TryGetValue(oldState.StateValue, out var list))
            {
                list = new List<PuzzleStateMutation>();
                Mutations[oldState.StateValue] = list;
            }

            var mutation = new PuzzleStateMutation(this, oldState, newState);
            mutation.Actions.Add(new Tuple<PuzzleElement, State>(this, newState));
            list.Add(mutation);

            return mutation;
        }
    }
}
