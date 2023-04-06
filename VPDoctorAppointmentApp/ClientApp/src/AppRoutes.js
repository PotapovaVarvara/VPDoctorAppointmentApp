import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import Dashboard from "./components/Dashboard/Dashboard.tsx";
//import  Dashboard  from "./components/Dashboard/Dashboard";

const AppRoutes = [
  {
    index: true,
    element: <Dashboard />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
