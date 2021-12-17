using System.Collections.Generic;

namespace QLearning
{
    // Класс реализующий фасад Q алгоритма для задачи выхода из комнаты
    class RoomsProblem : IQLearningProblem
    {
        // Матрица вознагрождения 
        private readonly double[][] _rewards = new double[16][]
        {
            //              0   1   2   3   4   5     6     7   8   9    10  11  12  13  14  15
            new double[] { -1, +0, -1, -1,-100, -1,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 0
            new double[] { 100,-1, +0, -1, -1,-100,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 1
            new double[] { -1, +0, -1, +0, -1,  -1,-100,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 2
            new double[] { -1, -1, +0, -1, -1,  -1,  -1,   +0,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 3
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 4
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 5
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 6
            new double[] { -1, -1, -1, +0, -1,  -1,-100,   -1,  -1, -1,  -1, +0,  -1, -1, -1, -1, }, // 7
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 8
            new double[] { -1, -1, -1, -1, -1,-100,  -1,   -1,-100, -1,-100, -1,  -1, +0, -1, -1, }, // 9
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 10
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   +0,  -1, -1,-100, -1,  -1, -1, -1, +0, }, // 11
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,  -1, -1,  -1, -1, -1, -1, }, // 12
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, +0,  -1, -1,-100, -1, +0, -1, }, // 13
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,-100, -1,  -1, +0, -1, +0, }, // 14
            new double[] { -1, -1, -1, -1, -1,  -1,  -1,   -1,  -1, -1,  -1, +0,  -1, -1, +0, -1, }, // 15
        };

        // Количество состояний (комнат)
        public int NumberOfStates => 16;

        // Количество действий (переходов)
        public int NumberOfActions => 16;

        // Возвращает вознаграждение
        public double GetReward(int currentState, int action)
        {
            return _rewards[currentState][action];
        }

        // Возвращает возможные действия
        public int[] GetValidActions(int currentState)
        {
            List<int> validActions = new List<int>();
            for (int i = 0; i < _rewards[currentState].Length; i++)
            {
                if (_rewards[currentState][i] != -1)
                    validActions.Add(i);
            }

            return validActions.ToArray();
        }

        // Достигли ли цели?
        public bool GoalStateIsReached(int currentState)
        {
            return currentState == 0;
        }

        public int ConvertRandomIndex(int index)
        {
            if (index > 9)
            {
                return index + 1;
            }

            return index;
        }
    }
}