import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import TaskCard from "./components/TaskCard";
import { TaskContextProvider } from "./contexts/TaskContext";

const App = () => (
  <TaskContextProvider>
    <div className="h-screen flex flex-col items-center justify-center">
      <TaskCard />
    </div>
    <ToastContainer />
  </TaskContextProvider>
);

export default App;
