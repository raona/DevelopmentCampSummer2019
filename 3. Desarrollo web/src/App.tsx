import React from 'react';
import Home from './home/home';
import Patients from './patients/patients';
import RespiNavbar from './common/navbar/respiNavbar';
import respiNavItems from './constants/respiNavItems';

export interface AppState {
	currentView: JSX.Element;
}

class App extends React.Component<{}, AppState> {
	state = {
		currentView: <Home />
	};

	handleNavbarSelect = (eventKey: string) => {
		let view: JSX.Element | undefined = undefined;

		switch (eventKey) {
			case 'home':
				view = <Home />;
				break;

			case 'patients':
				view = <Patients />
				break;
		}

		this.setState({
			currentView: view!
		});
	}

	public render() {
		let { currentView } = this.state;

		return (
			<>
				<RespiNavbar handleNavBarSelect={this.handleNavbarSelect} respiNavItems={respiNavItems} defaultActiveKey={respiNavItems[0].key}></RespiNavbar>
				{currentView}
			</>
		);
	}
}

export default App;
