namespace PuzzleSolver.Algorithm
{
    using System.Text;

    public class PuzzleElementState
    {
        public PuzzleElementState(PuzzleElement element, State state)
        {
            Element = element;
            State = state;
        }

        public PuzzleElement Element { get; }
        public State State { get; }

        public void WriteState(StringBuilder sb)
        {
            sb.Append($"[{Element.ElementName}={State}]");
        }
    }

    public struct State
    {
        public State(int stateValue)
        {
            if (stateValue > 7 || stateValue == -1)
                throw new InvalidOperationException();

            StateValue = stateValue;
            IsMultiple = false;
            MultistateArray = null;
        }

        public State(byte[] array)
        {
            var result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result |= array[i] << i * 4;
            }

            StateValue = result;
            IsMultiple = true;
            MultistateArray = array;
        }

        public int StateValue { get; }
        public bool IsMultiple { get; }
        public byte[]? MultistateArray { get; }

        #region Overrides of ValueType

        public override string ToString()
        {
            if (IsMultiple)
                return $"({string.Join("-", MultistateArray)})";

            return StateValue.ToString();
        }

        #endregion
    }
}
