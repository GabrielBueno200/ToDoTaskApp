import { useContext, useState } from "react";
import { AiFillDelete } from "react-icons/ai";
import { FiEdit2 } from "react-icons/fi";
import TaskContext from "../../contexts/TaskContext";
import { Task } from "../../types";
import EditTaskComponent from "../EditTaskComponent";

interface ITaskComponentProps {
  task: Task;
}

const TaskComponent = ({ task }: ITaskComponentProps) => {
  const { removeTask } = useContext(TaskContext);

  const [isEditing, setIsEditing] = useState(false);

  const handleIsEditing = (value: boolean) => setIsEditing(value);

  const handleDeleteTask = () => removeTask(task.id!);

  return !isEditing ? (
    <div className="flex items-center gap-2">
      <div className="bg-blue-100 p-1 rounded-md flex-1">
        <span
          className={`${
            task.isFinished ? "text-green-700" : "text-red-900"
          } font-medium`}
        >
          {task.isFinished ? "Finalizada:" : "Pendente:"}
        </span>

        {task.description}
      </div>

      <div className="flex gap-2">
        <AiFillDelete
          className="fill-red-900 cursor-pointer"
          size={20}
          onClick={handleDeleteTask}
        />
        <FiEdit2
          className="fill-blue-900 cursor-pointer"
          size={20}
          onClick={() => handleIsEditing(true)}
        />
      </div>
    </div>
  ) : (
    <EditTaskComponent
      task={task}
      onFinishEdition={() => handleIsEditing(false)}
    />
  );
};

export default TaskComponent;
