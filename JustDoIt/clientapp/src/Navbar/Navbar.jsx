import React from 'react';
import { NavLink } from 'react-router-dom';
import classes from './Navbar.module.css';


const Navbar = () => {
    return <nav className={classes.nav}>
        <div className = {classes.item}>
            <NavLink to = '/Login' activeClassName = {classes.active}>Login or registrate</NavLink>
        </div>
        <div className = {classes.item}>
            <NavLink to = '/Users' activeClassName = {classes.active}>Users</NavLink>
        </div>
        <div className = {classes.item}>
            <NavLink to ='/Notes' activeClassName = {classes.active}>Notes</NavLink>
        </div>
        
    </nav>
}

export default Navbar;