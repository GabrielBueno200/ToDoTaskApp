import api from "../api";
import { Task } from "../types";

export const getTasksAsync = async (): Promise<Task[]> => await api.get<Task[]>("/task");

export const addTaskAsync = async (task: Task): Promise<Task> => await api.post<Task>("/task", task);

export const deleteTaskAsync = async (taskId: number): Promise<void> => await api.delete(`/task/${taskId}`);

export const updateTaskAsync = async (task: Task): Promise<void> => await api.put<Task>("/task", task);