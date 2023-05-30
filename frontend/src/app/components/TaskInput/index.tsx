import { useContext, useState } from "react";
import Button from "../../common/components/Button";
import TaskContext from "../../contexts/TaskContext";

const TaskInput = () => {
  const [newTaskDescription, setNewTaskDescription] = useState("");

  const { addTask } = useContext(TaskContext);

  const handleSetNewTaskDescription = (
    e: React.ChangeEvent<HTMLInputElement>
  ) => setNewTaskDescription(e.target.value);

  const handleAddNewTask = () =>
    addTask({ description: newTaskDescription, isFinished: false });

  return (
    <div className="flex justify-between gap-2 mb-2 h-10">
      <input
        className="border-black shadow-md p-1 rounded-md flex-1"
        type="text"
        value={newTaskDescription}
        placeholder="Digite a descrição da tarefa a ser adicionada"
        onChange={handleSetNewTaskDescription}
      />
      <Button title="Adicionar" onClick={handleAddNewTask} />
    </div>
  );
};

export default TaskInput;
