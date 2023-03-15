# PuzzleSolver

Prototype of puzzle solver algorithm.

Solves a given puzzle using a LPS (Logic production system) with Forward chaining approach.

No UI or visual simulation. 

Puzzle logic is defined in MainCode.cs. Should be adjusted or totally rewritten for a new puzzle.

![image](https://user-images.githubusercontent.com/7633163/225441120-83cccd04-488d-4073-895e-d96138ac2fa3.png)


```
[Player:4->3]
[Disabler:3->(3-9)][Door9:1->0]
[Player:3->2]
[Cube2:2->3][Player:2->3]
[Disabler:(3-9)->3][Door9:0->1]
[Disabler:3->4][Player:3->4]
[Disabler:4->(4-14)][Door14:1->0]
[Player:4->5]
[Prism:5->4][Player:5->4]
[Disabler:(4-14)->4][Door14:0->1]
[Disabler:4->(4-8)][Door8:1->0]
[Prism:4->(4-12)][RedReceiver12:0->1][Door11:1->0]
[Cube1:4->2][Player:4->2]
[Cube1:2->1][Player:2->1]
[Player:1->2]
[Player:2->4]
[Prism:(4-12)->4][RedReceiver12:1->0][Door11:0->1]
[Prism:4->2][Player:4->2]
[Prism:2->(2-10)][BlueReceiver10:0->1][Fan13:0->1]
[Cube1:1->7]
[Prism:(2-10)->2][BlueReceiver10:1->0][Fan13:1->0]
[Prism:2->4][Player:2->4]
[Disabler:(4-8)->4][Door8:0->1]
[Prism:4->(4-15)][RedReceiver15:0->1][Door14:1->0]
[Disabler:4->5][Player:4->5]
[Disabler:5->(5-16)][Fan16:1->0]
[Player:5->6]
[Player:6->7]
```
