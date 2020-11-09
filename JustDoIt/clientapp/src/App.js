import * as React from 'react';
import './App.css';
import Header from './Header/Header.jsx';
import Navbar from './Navbar/Navbar.jsx';
import { BrowserRouter, Route } from 'react-router-dom';
import UserList from './Users/UserList.jsx';
import NoteList from './Notes/NoteList';
import MainPage from './MainPage/MainPage';
import Login from './Login/Login';

const App = () => {
  return (
    <BrowserRouter>
      <div className='app-wrapper'>
        <Header />
        <Navbar />
        <div className='app-wrapper-content'>
          <Route path = '/Login'>
              <Login /> 
          </Route>
          <Route exact path='/' component={MainPage} >
            
          </Route>
          <Route path='/Users' >
            <UserList  />
          </Route>
          <Route path='/Notes'>
            <NoteList  />
          </Route>
        </div>
      </div>
    </BrowserRouter>
  )
}
export default App;
