import {
  Dispatch,
  ReactNode,
  SetStateAction,
  createContext,
  useEffect,
  useState,
} from "react";
import { Task } from "../types";
import {
  addTaskAsync,
  deleteTaskAsync,
  getTasksAsync,
  updateTaskAsync,
} from "../utils/taskRequests";

interface ITaskContextProps {
  tasks: Task[];
  finishedTasks: Task[];
  pendentTasks: Task[];
  setTasks: Dispatch<SetStateAction<Task[]>>;
  removeTask: (taskId: number) => Promise<void>;
  updateTask: (task: Task) => Promise<void>;
  addTask: (task: Task) => Promise<void>;
}

const TaskContext = createContext<ITaskContextProps>({} as ITaskContextProps);

export const TaskContextProvider = ({ children }: { children: ReactNode }) => {
  const [tasks, setTasks] = useState<Task[]>([]);

  const finishedTasks = tasks?.filter(task => task.isFinished)
  const pendentTasks = tasks?.filter(task => !task.isFinished)

  useEffect(() => {
    getTasksAsync().then(setTasks);
  }, []);

  const addTask = async (taskToCreate: Task): Promise<void> => {
    addTaskAsync(taskToCreate).then((createdTask) =>
      setTasks([...tasks, createdTask])
    );
  };

  const removeTask = async (taskId: number): Promise<void> => {
    deleteTaskAsync(taskId).then(() =>
      setTasks((previousTasks) =>
        previousTasks.filter((task) => task.id !== taskId)
      )
    );
  };

  const updateTask = async (updatedTask: Task): Promise<void> => {
    updateTaskAsync(updatedTask).then(() =>
      setTasks((previousTasks) =>
        previousTasks.map((task) => {
          if (task.id === updatedTask.id) return updatedTask;
          return task;
        })
      )
    );
  };

  const contextValue: ITaskContextProps = {
    tasks,
    finishedTasks,
    pendentTasks,
    setTasks,
    addTask,
    removeTask,
    updateTask
  };

  return (
    <TaskContext.Provider value={contextValue}>{children}</TaskContext.Provider>
  );
};

export default TaskContext;
