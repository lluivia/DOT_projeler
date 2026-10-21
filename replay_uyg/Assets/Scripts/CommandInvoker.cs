using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    public static CommandInvoker Instance { get; private set; }
    private static readonly Stack<ICommand> UndoStack = new Stack<ICommand>();
    private static readonly List<ICommand> CommandHistory = new List<ICommand>();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            UndoStack.Clear();
            CommandHistory.Clear();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();
        UndoStack.Push(command);
        CommandHistory.Add(command);
    }

    public static void UndoCommand()
    {
        if (UndoStack.Count > 0)
        {
            ICommand command = UndoStack.Pop();
            command.Undo();

            if (CommandHistory.Count > 0)
            {
                CommandHistory.RemoveAt(CommandHistory.Count - 1);
            }
        }
    }

    public void StartReplay(Transform targetTransform, Vector3 startPosition)
    {
        StartCoroutine(ReplayRoutine(targetTransform, startPosition));
    }

    private IEnumerator ReplayRoutine(Transform targetTransform, Vector3 startPosition)
    {
        targetTransform.position = startPosition;
        yield return new WaitForSeconds(0.6f);
        
        foreach (ICommand command in CommandHistory)
        {
            command.Execute();
            yield return new WaitForSeconds(0.6f);
        }
    }
}