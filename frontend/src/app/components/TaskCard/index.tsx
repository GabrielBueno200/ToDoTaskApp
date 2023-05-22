import { useContext, useEffect, useState } from "react";
import { AiFillFilter } from "react-icons/ai";
import TaskContext from "../../contexts/TaskContext";
import TaskComponent from "../TaskComponent";
import TaskInput from "../TaskInput";

type filterOptions = "finished" | "pendent" | "all";

const TaskCard = () => {
  const { tasks, pendentTasks, finishedTasks } = useContext(TaskContext);

  const [statusFilterOption, setStatusFilterOption] = useState<
    "finished" | "pendent" | "all"
  >("all");

  const [descriptionFilter, setDescriptionFilter] = useState("");

  useEffect(() => {
    setStatusFilterOption("all");
  }, [descriptionFilter]);

  const handleSetDescriptionFilter = (e: React.ChangeEvent<HTMLInputElement>) =>
    setDescriptionFilter(e.target.value);

  const tasksFilteredByDescription = tasks.filter((task) =>
    task.description.toLowerCase().includes(descriptionFilter.toLowerCase())
  );

  const filteredTasks =
    descriptionFilter.length > 0
      ? tasksFilteredByDescription
      : statusFilterOption === "finished"
      ? finishedTasks
      : statusFilterOption === "pendent"
      ? pendentTasks
      : tasks;

  const handleSetStatusFilterOption = (
    e: React.ChangeEvent<HTMLSelectElement>
  ) => setStatusFilterOption(e.target.value as filterOptions);

  return (
    <div className="bg-slate-300 md:w-2/5 sm:w-8/12 rounded-lg p-7 shadow-lg">
      <h1 className="font-bold text-center p-4 text-lg">Lista de tarefas</h1>
      <TaskInput />

      <div className="flex items-center mt-3 mb-3 h-14 justify-between">
        <input
          className="border-black shadow-md p-1 rounded-md w-72"
          type="text"
          value={descriptionFilter}
          placeholder="Digite a tarefa a ser pesquisada..."
          onChange={handleSetDescriptionFilter}
        />
        <div className="flex items-center gap-2">
          <AiFillFilter size={24} />
          <select
            onChange={handleSetStatusFilterOption}
            value={statusFilterOption}
            className="shadow-md p-1 rounded-md"
          >
            <option value="all">Todas</option>
            <option value="pendent">Pendentes</option>
            <option value="finished">Finalizadas</option>
          </select>
        </div>
      </div>
      <div className="flex flex-col gap-2 overflow-auto max-h-72 pr-3">
        {filteredTasks.map((task) => (
          <TaskComponent key={task.id} task={task} />
        ))}
      </div>
    </div>
  );
};

export default TaskCard;
