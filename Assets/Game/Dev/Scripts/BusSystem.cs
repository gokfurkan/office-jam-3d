using System;
using UnityEngine;

namespace Game.Dev.Scripts
{
    public static class BusSystem
    {
        //Economy
        public static Action <int> OnAddMoneys;
        public static void CallAddMoneys(int amount) { OnAddMoneys?.Invoke(amount); }
        
        public static Action OnResetMoneys;
        public static void CallResetMoneys() { OnResetMoneys?.Invoke(); }
        
        public static Action OnSetMoneys;
        public static void CallSetMoneys() { OnSetMoneys?.Invoke(); }
        
        //Game Manager
        
        public static Action OnLevelStart;
        public static void CallLevelStart() { OnLevelStart?.Invoke(); }
     
        public static Action <bool> OnLevelEnd;
        public static void CallLevelEnd(bool win) { OnLevelEnd?.Invoke(win); }
     
        public static Action OnLevelLoad;
        public static void CallLevelLoad() { OnLevelLoad?.Invoke(); }
        
        //Input
        
        public static Action OnMouseClickDown;
        public static void CallMouseClickDown() { OnMouseClickDown?.Invoke(); }
        
        public static Action OnMouseClicking;
        public static void CallMouseClicking() { OnMouseClicking?.Invoke(); }
        
        public static Action OnMouseClickUp;
        public static void CallMouseClickUp() { OnMouseClickUp?.Invoke(); }
        
        //
        
        public static Action <GameObject> OnSelectChair;
        public static void CallSelectChair(GameObject selectedObject) { OnSelectChair?.Invoke(selectedObject); }
        
        public static Action OnSuccessMoveSequence;
        public static void CallSuccessMoveSequence() { OnSuccessMoveSequence?.Invoke(); }
    }
}