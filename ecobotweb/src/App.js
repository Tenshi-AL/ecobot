import './App.css';
import Sidebar from './components/Sidebar/Sidebar';
import { BrowserRouter,Routes, Route } from "react-router-dom";
import StationPage from './pages/StationPage';


function App() {
  return (
    <div className="App">
      <div class="wrapper">
      <BrowserRouter>
        <Sidebar/>
          <div className='page-content-wrapper'>
          <Routes>
            <Route path='/stations' element={<StationPage/>}/>
          </Routes>
          </div>
        </BrowserRouter>
      </div>
    </div>
  );
}
export default App;
