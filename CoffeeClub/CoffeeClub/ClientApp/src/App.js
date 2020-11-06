import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import Register from './components/Register';
import './custom.css'
import OnTheSpotMatch from './components/OnTheSpotMatch';
import RecurrentMatch from './components/RecurrentMatch';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/on-the-spot-match' component={OnTheSpotMatch} />
        <Route path='/register' component={Register} />
        <Route path='/recurrent-match' component={RecurrentMatch} />
      </Layout>
    );
  }
}
