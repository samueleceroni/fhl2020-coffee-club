import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Matcher } from './components/Matcher';
import './custom.css'
import OnTheSpotMatch from './components/OnTheSpotMatch';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/get-matches/:id?' component={Matcher} />
        <Route path='/on-the-spot-match' component={OnTheSpotMatch} />
      </Layout>
    );
  }
}
