namespace TicTacToe
{
    public static class Utils
    {
        public static char GetStateChar(this State state) =>
            state == State.Cross
                ? 'x'
                : state == State.Zero
                    ? 'o' :
                    '.';
    }
}