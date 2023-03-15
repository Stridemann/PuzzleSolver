namespace PuzzleSolver.Algorithm
{
    public class MainCode
    {
        private static PuzzleElement _player0;
        private static PuzzleElement _cube1;
        private static PuzzleElement _cube2;
        private static PuzzleElement _disabler3;
        private static PuzzleElement _prism4;
        private static PuzzleElement _laserRed5;
        private static PuzzleElement _receiverRed6;
        private static PuzzleElement _laserBlue7;
        private static PuzzleElement _door8;
        private static PuzzleElement _door9;
        private static PuzzleElement _receiverBlue10;
        private static PuzzleElement _door11;
        private static PuzzleElement _receiverRed12;
        private static PuzzleElement _fan13;
        private static PuzzleElement _door14;
        private static PuzzleElement _receiverRed15;
        private static PuzzleElement _fan16;
        private static PuzzleElement _receiverRed17;

        private const byte ROOM1 = 1;
        private const byte ROOM2 = 2;
        private const byte ROOM3 = 3;
        private const byte ROOM4 = 4;
        private const byte ROOM5 = 5;
        private const byte ROOM6 = 6;
        private const byte ROOM7 = 7;
        private const byte ON = 1;
        private const byte OFF = 0;

        public static void Main()
        {
            _player0 = new PuzzleElement(0, "Player", ROOM4);
            _cube1 = new PuzzleElement(1, "Cube1", ROOM4);
            _cube2 = new PuzzleElement(2, "Cube2", ROOM2);
            _disabler3 = new PuzzleElement(3, "Disabler", ROOM3);
            _prism4 = new PuzzleElement(4, "Prism", ROOM5);

            _laserRed5 = new PuzzleElement(5, "RedLaser5", ON);
            _receiverRed6 = new PuzzleElement(6, "RedReceiver6", OFF);
            _laserBlue7 = new PuzzleElement(7, "BlueLaser7", ON);
            _door8 = new PuzzleElement(8, "Door8", ON);
            _door9 = new PuzzleElement(9, "Door9", ON);
            _receiverBlue10 = new PuzzleElement(10, "BlueReceiver10", OFF);
            _door11 = new PuzzleElement(11, "Door11", ON);
            _receiverRed12 = new PuzzleElement(12, "RedReceiver12", OFF);
            _fan13 = new PuzzleElement(13, "Fan13", OFF);
            _door14 = new PuzzleElement(14, "Door14", ON);
            _receiverRed15 = new PuzzleElement(15, "RedReceiver15", OFF);
            _fan16 = new PuzzleElement(16, "Fan16", ON);
            _receiverRed17 = new PuzzleElement(17, "RedReceiver17", OFF);

            var puzzle = new Puzzle();

            var puzzleElements = new List<PuzzleElement>
            {
                _player0,
                _cube1,
                _cube2,
                _disabler3,
                _prism4,
                _laserRed5,
                _receiverRed6,
                _laserBlue7,
                _door8,
                _door9,
                _receiverBlue10,
                _door11,
                _receiverRed12,
                _fan13,
                _door14,
                _receiverRed15,
                _fan16,
                _receiverRed17
            };

            var finalCondition = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(_player0.Id, ROOM7),
                new Tuple<int, int>(_cube1.Id, ROOM7),

                //new Tuple<int, int>(_player.Id, ROOM4),
                //new Tuple<int, int>(_disabler4.Id, ROOM4),
                //new Tuple<int, int>(_door15.Id, OFF)
            };

            #region Player Mutations

            _player0.AddMutation(ROOM1, ROOM7).AddCondition(_fan13, ON);
            _player0.AddMutation(ROOM1, ROOM2).AddCondition(_door11, OFF);

            _player0.AddMutation(ROOM2, ROOM1).AddCondition(_door11, OFF);
            _player0.AddMutation(ROOM2, ROOM3).AddCondition(_door9, OFF);
            _player0.AddMutation(ROOM2, ROOM4).AddCondition(_door8, OFF);

            _player0.AddMutation(ROOM3, ROOM2).AddCondition(_door9, OFF);
            _player0.AddMutation(ROOM3, ROOM4).AddCondition(_cube1, ROOM3);
            _player0.AddMutation(ROOM3, ROOM4).AddCondition(_cube2, ROOM3);

            _player0.AddMutation(ROOM4, ROOM3).AddCondition(_cube1, ROOM4);
            _player0.AddMutation(ROOM4, ROOM3).AddCondition(_cube2, ROOM4);
            _player0.AddMutation(ROOM4, ROOM2).AddCondition(_door8, OFF);
            _player0.AddMutation(ROOM4, ROOM5).AddCondition(_door14, OFF);

            _player0.AddMutation(ROOM5, ROOM4).AddCondition(_door14, OFF);
            _player0.AddMutation(ROOM5, ROOM6).AddCondition(_fan16, OFF);

            _player0.AddMutation(ROOM6, ROOM5);
            _player0.AddMutation(ROOM6, ROOM7);
            _player0.AddMutation(ROOM7, ROOM6);

            #endregion

            #region Moving items

            RegisterElementMovement(_cube1, true);
            RegisterElementMovement(_cube2, true);

            _cube2.AddMutation(ROOM3, ROOM4).AddCondition(_cube1, ROOM4).AddCondition(_player0, ROOM4);
            _cube1.AddMutation(ROOM3, ROOM4).AddCondition(_cube2, ROOM4).AddCondition(_player0, ROOM4);

            _cube2.AddMutation(ROOM4, ROOM3).AddCondition(_cube1, ROOM3).AddCondition(_player0, ROOM3);
            _cube1.AddMutation(ROOM4, ROOM3).AddCondition(_cube2, ROOM3).AddCondition(_player0, ROOM3);

            RegisterElementMovement(_disabler3);

            RegisterElementMovement(_prism4);

            #endregion

            #region Game Logic Elements

            var prism4210 = AddPrismMutation(
                _prism4,
                ROOM2,
                _receiverBlue10,
                _fan13,
                1,
                0);

            prism4210.Item1.AddCondition(_door8, OFF);
            prism4210.Item2.AddCondition(_door8, OFF);

            AddPrismMutation(_prism4, ROOM4, _receiverRed6, _door8);
            var r13 = AddPrismMutation(_prism4, ROOM4, _receiverRed12, _door11);
            r13.Item1.AddCondition(_door8, OFF);
            r13.Item2.AddCondition(_door8, OFF);

            var prism4_7_13 = new[] { ROOM4, _receiverRed6.Id, _receiverRed12.Id };

            _prism4.AddMutation(ROOM4, prism4_7_13)
                   .AddCondition(_player0, ROOM4)
                   .AddAction(_receiverRed6, ON)
                   .AddAction(_receiverRed12, ON)
                   .AddAction(_door11, OFF)
                   .AddAction(_door8, OFF);

            _prism4.AddMutation(prism4_7_13, ROOM4)
                   .AddCondition(_player0, ROOM4)
                   .AddAction(_receiverRed6, OFF)
                   .AddAction(_receiverRed12, OFF)
                   .AddAction(_door11, ON)
                   .AddAction(_door8, ON);

            AddPrismMutation(_prism4, ROOM4, _receiverRed15, _door14);
            AddPrismMutation(_prism4, ROOM4, _receiverRed15, _door14);

            AddDisablerMutation(ROOM3, _door9);
            AddDisablerMutation(ROOM4, _door14);
            AddDisablerMutation(ROOM4, _door8);
            AddDisablerMutation(ROOM2, _door9);
            AddDisablerMutation(ROOM2, _door11);
            AddDisablerMutation(ROOM6, _fan16);
            AddDisablerMutation(ROOM5, _fan16);
            var disabler4_16 = AddDisablerMutation(ROOM4, _fan16);
            disabler4_16.Item1.AddCondition(_door14, OFF);
            disabler4_16.Item2.AddCondition(_door14, OFF);

            var dis_4_12 = AddDisablerMutation(ROOM4, _door11);
            dis_4_12.Item1.AddCondition(_door8, OFF);
            dis_4_12.Item2.AddCondition(_door8, OFF);

            #endregion

            var result = puzzle.Process(puzzleElements, finalCondition);
        }

        private static (PuzzleStateMutation, PuzzleStateMutation) AddDisablerMutation(byte room, PuzzleElement activateElement)
        {
            var newState = new[] { room, activateElement.Id };
            var mutation1 = _disabler3.AddMutation(room, newState).AddCondition(_player0, room).AddAction(activateElement, OFF);
            var mutation2 = _disabler3.AddMutation(newState, room).AddCondition(_player0, room).AddAction(activateElement, ON);

            return (mutation1, mutation2);
        }

        private static (PuzzleStateMutation, PuzzleStateMutation) AddPrismMutation(
            PuzzleElement element,
            byte room,
            PuzzleElement receiver,
            PuzzleElement door,
            int state1 = 0,
            int state2 = 1)
        {
            var prismState = new[] { room, receiver.Id };
            var mutation1 = element.AddMutation(room, prismState).AddCondition(_player0, room).AddAction(receiver, ON).AddAction(door, state1);
            var mutation2 = element.AddMutation(prismState, room).AddCondition(_player0, room).AddAction(receiver, OFF).AddAction(door, state2);

            return (mutation1, mutation2);
        }

        private static void RegisterElementMovement(PuzzleElement element, bool isCube = false)
        {
            element.AddMutation(ROOM1, ROOM7).AddCondition(_fan13, ON);
            AddMoveMutationIfDoorOpened(element, ROOM1, ROOM2, _door11);

            AddMoveMutationIfDoorOpened(element, ROOM2, ROOM3, _door9);
            AddMoveMutationIfDoorOpened(element, ROOM2, ROOM4, _door8);

            if (!isCube)
            {
                element.AddMutation(ROOM3, ROOM4)
                       .AddCondition(_cube1, ROOM3)
                       .AddCondition(_cube2, ROOM4)
                       .AddCondition(_player0, ROOM3)
                       .AddAction(_player0, ROOM4);

                element.AddMutation(ROOM3, ROOM4)
                       .AddCondition(_cube2, ROOM3)
                       .AddCondition(_cube1, ROOM4)
                       .AddCondition(_player0, ROOM3)
                       .AddAction(_player0, ROOM4);

                element.AddMutation(ROOM4, ROOM3)
                       .AddCondition(_cube1, ROOM3)
                       .AddCondition(_cube2, ROOM4)
                       .AddCondition(_player0, ROOM4)
                       .AddAction(_player0, ROOM3);

                element.AddMutation(ROOM4, ROOM3)
                       .AddCondition(_cube2, ROOM3)
                       .AddCondition(_cube1, ROOM4)
                       .AddCondition(_player0, ROOM4)
                       .AddAction(_player0, ROOM3);
            }

            element.AddMutation(ROOM4, ROOM5).AddCondition(_door14, OFF).AddCondition(_player0, ROOM4).AddAction(_player0, ROOM5);
            element.AddMutation(ROOM5, ROOM4).AddCondition(_door14, OFF).AddCondition(_player0, ROOM5).AddAction(_player0, ROOM4);

            element.AddMutation(ROOM5, ROOM6).AddCondition(_fan16, OFF).AddCondition(_player0, ROOM5).AddAction(_player0, ROOM6);
            element.AddMutation(ROOM6, ROOM5).AddCondition(_player0, ROOM6).AddAction(_player0, ROOM5);
        }

        private static void AddMoveMutationIfDoorOpened(
            PuzzleElement element,
            int fromRoom,
            int toRoom,
            PuzzleElement door)
        {
            element.AddMutation(fromRoom, toRoom).AddCondition(door, OFF).AddCondition(_player0, fromRoom).AddAction(_player0, toRoom);
            element.AddMutation(toRoom, fromRoom).AddCondition(door, OFF).AddCondition(_player0, toRoom).AddAction(_player0, fromRoom);
        }
    }
}
