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
  removeTask: (taskId: number) => void;
  updateTask: (task: Task) => void;
  addTask: (task: Task) => void;
}

const TaskContext = createContext<ITaskContextProps>({} as ITaskContextProps);

export const TaskContextProvider = ({ children }: { children: ReactNode }) => {
  const [tasks, setTasks] = useState<Task[]>([]);

  const finishedTasks = tasks?.filter((task) => task.isFinished);
  const pendentTasks = tasks?.filter((task) => !task.isFinished);

  useEffect(() => {
    getTasksAsync().then(setTasks);
  }, []);

  const addTask = (taskToCreate: Task) => {
    addTaskAsync(taskToCreate).then((createdTask) =>
      setTasks([...tasks, createdTask])
    );
  };

  const removeTask = (taskId: number) => {
    deleteTaskAsync(taskId).then(() =>
      setTasks((previousTasks) =>
        previousTasks.filter((task) => task.id !== taskId)
      )
    );
  };

  const updateTask = (updatedTask: Task) => {
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
    updateTask,
  };

  return (
    <TaskContext.Provider value={contextValue}>{children}</TaskContext.Provider>
  );
};

export default TaskContext;
