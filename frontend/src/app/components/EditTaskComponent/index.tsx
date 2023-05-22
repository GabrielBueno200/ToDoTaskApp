import { useContext, useState } from "react";
import { GiCancel, GiConfirmed } from "react-icons/gi";
import Button from "../../common/components/Button";
import TaskContext from "../../contexts/TaskContext";
import { Task } from "../../types";

interface IEditTaskComponentProps {
  onFinishEdition: () => void;
  task: Task;
}

const EditTaskComponent = ({
  onFinishEdition,
  task,
}: IEditTaskComponentProps) => {
  const [isFinished, setIsFinished] = useState(task.isFinished);
  const [newTaskDescription, setNewTaskDescription] = useState(
    task.description
  );

  const { updateTask } = useContext(TaskContext);

  const handleConfirmEdition = () => {
    onFinishEdition();
    updateTask({ ...task, description: newTaskDescription, isFinished });
  };

  const handleIsFinished = (value: boolean) => setIsFinished(value);

  const handleSetNewTaskDescription = (
    e: React.ChangeEvent<HTMLInputElement>
  ) => setNewTaskDescription(e.target.value);

  return (
    <div className="flex items-center gap-2">
      <div className="bg-blue-100 p-1 rounded-md flex flex-1 justify-between gap-1">
        <input
          type="text"
          className="h-10 flex-1"
          value={newTaskDescription}
          onChange={handleSetNewTaskDescription}
        />
        <div className="flex gap-1">
          <Button
            color="red"
            title="Pendente"
            onClick={() => handleIsFinished(false)}
            className={`${!isFinished ? "opacity-100" : "opacity-50"}`}
          />
          <Button
            title="Finalizada"
            onClick={() => handleIsFinished(true)}
            className={`${isFinished ? "opacity-100" : "opacity-50"}`}
          />
        </div>
      </div>

      <div className="flex gap-2">
        <GiConfirmed
          className="fill-green-900 cursor-pointer"
          size={20}
          onClick={handleConfirmEdition}
        />
        <GiCancel
          className="fill-red-900 cursor-pointer"
          size={20}
          onClick={onFinishEdition}
        />
      </div>
    </div>
  );
};

export default EditTaskComponent;
