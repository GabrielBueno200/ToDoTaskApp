import TaskCard from "./components/TaskCard";
import { TaskContextProvider } from "./contexts/TaskContext";

const App = () => (
  <TaskContextProvider>
    <div className="h-screen flex flex-col items-center justify-center">
      <TaskCard />
    </div>
  </TaskContextProvider>
);

export default App;
