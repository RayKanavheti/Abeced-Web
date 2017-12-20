﻿define(['kendo/kendo.combobox.min', 'kendo/kendo.treeview.min'], function (kendo) {
    var DropDownTreeView = kendo.ui.ComboBox.extend({
        _treeview: null,
        init: function (element, options) {
            kendo.ui.ComboBox.fn.init.call(this, element, options);
            var self = this;
            self.popup.canClose = true;

            var id = $(this.element).attr('id') + '-treeview';
            self._treeview = $('<div id="' + id + '"></div>')
            .kendoTreeView({
                dataSource: [],
                dataTextField: self.options.dataTextField,
                dataValueField: self.options.dataValueField,
                loadOnDemand: false,
                autoBind: false,
                select: function (e) {
                    var item = self._treeview.getKendoTreeView().dataItem(e.node);
                    self.value(item[self.options.dataValueField]);
                    self.trigger('change');
                    self.popup.canClose = true;
                    self.popup.close();
                },
                collapse: function () {
                    self.popup.canClose = false;
                },
                expand: function () {
                    self.popup.canClose = false;
                }
            });
            $('ul', self.list).replaceWith(self._treeview).remove();
            self.popup.bind('close', function (e) {
                if (!self.popup.canClose) {
                    e.preventDefault();
                    self.popup.canClose = true;
                }
            });
            self._closeHandler = function (e) {
                self.popup.canClose = true;
                kendo.ui.ComboBox.fn._closeHandler.call(this, e);
            };
            self.bind('open', function () {
                if (self.value()) {
                    var treeview = self._treeview.getKendoTreeView();
                    var selectedNode = treeview.findByText(self.text());
                    treeview.expandTo(selectedNode);
                    treeview.select(selectedNode);
                }
            });
        },
        options: {
            name: 'DropDownTreeView',
            parentField: null,
        },
        refresh: function () {
            kendo.ui.ComboBox.fn.refresh.call(this);
            if (this._treeview.getKendoTreeView().dataSource.data().length == 0) {
                this._treeview.getKendoTreeView().dataSource.data(processTable(this.dataSource._pristineData, this.options.dataValueField, this.options.parentField));
            }
        }
    });
    kendo.ui.plugin(DropDownTreeView);

    function processTable(data, idField, foreignKey) {
        var hash = {},
        root = null;
        for (var i = 0; i < data.length; i++) {
            var item = data[i];
            var id = item[idField];
            var parentId = item[foreignKey];
            if (parentId == null) {
                root = id;
            }

            hash[id] = hash[id] || [];
            hash[parentId] = hash[parentId] || [];

            item.items = hash[id];
            hash[parentId].push(item);
        }
        return hash[root];
    }
});

